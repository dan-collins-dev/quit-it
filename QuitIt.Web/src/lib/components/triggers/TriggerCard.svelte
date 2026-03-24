<script>
	let { trigger, id, onDelete, onEdit } = $props();
	let isEditing = $state(false);
	let isDisabled = $state(true);

	function toggleEditMode() {
		isEditing = !isEditing;
		if (isEditing) {
			isDisabled = false;
		} else {
			isDisabled = true;
		}
	}

	function handleEdit(id) {
		onEdit(id, trigger);
		toggleEditMode();
	}
</script>

<article>
	<input type="text" bind:value={trigger} name="" disabled={isDisabled} />
	<div class="btn-container">
		{#if !isEditing}
			<button class="edit-btn" onclick={() => toggleEditMode()}>Edit</button>
			<button class="delete-btn" onclick={() => onDelete(id)}>Delete</button>
		{:else}
			<button class="save-btn" onclick={() => handleEdit(id)}>Save</button>
			<button class="cancel-btn" onclick={() => toggleEditMode()}>Cancel</button>
		{/if}
	</div>
</article>

<style>
	article {
		display: flex;
		flex-direction: column;
		justify-content: space-between;
		background-color: #fff;
		border-radius: 5px;
		box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
		padding: 1rem;
		margin: 0.75rem;
		gap: 1rem;
	}

	.btn-container {
		display: flex;
		flex-direction: column;
		gap: 1rem;
	}

	button {
		border: none;
		padding: 1rem 2rem;
		border-radius: 5px;	
	}

	.save-btn {
		background-color: green;
		color: white;
	}

	.edit-btn {
		background: linear-gradient(180deg, #0050ff, #070b47);
		color: white;
	}

	.delete-btn, .cancel-btn {
		background: linear-gradient(180deg, red, rgb(125, 0, 0));
		color: white;
	}
</style>
